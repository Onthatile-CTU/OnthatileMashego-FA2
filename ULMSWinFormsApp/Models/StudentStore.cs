/*using System;
using System.Collections.Generic;
using System.Text;

namespace ULMSWinFormsApp.Models
{
    internal class StudentStore
    {
    }
}
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ULMSWinFormsApp.Models
{
    /// <summary>
    /// Central in-memory store shared across all forms.
    /// Holds registered students, enrolments, and marks using a Dictionary keyed by StudentId.
    /// No database used — data lives for the lifetime of the application session.
    /// </summary>
    public static class StudentStore
    {
        // ── Student registry ────────────────────────────────────────────────
        // Key = StudentId (unique), Value = Student object
        private static readonly Dictionary<string, Student> _students
            = new Dictionary<string, Student>(System.StringComparer.OrdinalIgnoreCase);

        // ── Enrolments ──────────────────────────────────────────────────────
        // Key = StudentId, Value = list of Enrollment objects for that student
        private static readonly Dictionary<string, List<Enrollment>> _enrolments
            = new Dictionary<string, List<Enrollment>>(System.StringComparer.OrdinalIgnoreCase);

        // ── Marks ───────────────────────────────────────────────────────────
        // Key = StudentId, Value = MarkRecord for that student
        private static readonly Dictionary<string, MarkRecord> _marks
            = new Dictionary<string, MarkRecord>(System.StringComparer.OrdinalIgnoreCase);

        // ════════════════════════════════════════════════════════════════════
        // STUDENT METHODS
        // ════════════════════════════════════════════════════════════════════

        /// <summary>Returns true if a student with this ID already exists.</summary>
        public static bool StudentIdExists(string studentId)
            => _students.ContainsKey(studentId.Trim());

        /// <summary>
        /// Tries to register a student.
        /// Returns false (with reason) if the ID is taken or the email is duplicate.
        /// </summary>
        public static bool TryRegisterStudent(Student student, out string error)
        {
            string id = student.StudentId.Trim();

            if (_students.ContainsKey(id))
            {
                error = $"Student ID '{id}' is already registered. Each student must have a unique ID.";
                return false;
            }

            // Optional: block duplicate emails
            bool emailTaken = _students.Values
                .Any(s => s.Email.Equals(student.Email.Trim(),
                          System.StringComparison.OrdinalIgnoreCase));
            if (emailTaken)
            {
                error = $"A student with email '{student.Email}' is already registered.";
                return false;
            }

            _students[id] = student;
            error = null;
            return true;
        }

        /// <summary>
        /// Returns the registered student if the ID exists AND the name matches.
        /// Used by enrolment, marks, and reports to validate the ID+Name pair.
        /// </summary>
        public static bool TryGetStudent(string studentId, string fullName, out Student student)
        {
            string id = studentId.Trim();
            string name = fullName.Trim();

            if (_students.TryGetValue(id, out student))
            {
                // Name must match the one stored at registration (case-insensitive)
                if (student.FullName.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                    return true;

                student = null;
                return false;
            }

            student = null;
            return false;
        }

        /// <summary>Looks up a student by ID only (for report generation).</summary>
        public static bool TryGetStudentById(string studentId, out Student student)
            => _students.TryGetValue(studentId.Trim(), out student);

        /// <summary>Returns all registered students (read-only snapshot).</summary>
        public static IReadOnlyList<Student> GetAllStudents()
            => _students.Values.ToList().AsReadOnly();

        // ════════════════════════════════════════════════════════════════════
        // ENROLMENT METHODS
        // ════════════════════════════════════════════════════════════════════

        /// <summary>Returns true if the student is already enrolled in this course.</summary>
        public static bool IsEnrolled(string studentId, string courseName)
        {
            string id = studentId.Trim();
            if (!_enrolments.ContainsKey(id)) return false;
            return _enrolments[id].Any(e =>
                e.CourseName.Equals(courseName.Trim(),
                System.StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>Adds an enrolment for a verified student.</summary>
        public static void AddEnrolment(Enrollment enrollment)
        {
            string id = enrollment.StudentId.Trim();
            if (!_enrolments.ContainsKey(id))
                _enrolments[id] = new List<Enrollment>();
            _enrolments[id].Add(enrollment);
        }

        /// <summary>Returns all enrolments for a student (or empty list).</summary>
        public static IReadOnlyList<Enrollment> GetEnrolments(string studentId)
        {
            string id = studentId.Trim();
            return _enrolments.ContainsKey(id)
                ? _enrolments[id].AsReadOnly()
                : new List<Enrollment>().AsReadOnly();
        }

        // ════════════════════════════════════════════════════════════════════
        // MARKS METHODS
        // ════════════════════════════════════════════════════════════════════

        /// <summary>Saves or overwrites a mark record for a student.</summary>
        public static void SaveMarks(MarkRecord record)
            => _marks[record.StudentId.Trim()] = record;

        /// <summary>Returns a student's mark record, or null if none exists.</summary>
        public static MarkRecord GetMarks(string studentId)
        {
            _marks.TryGetValue(studentId.Trim(), out MarkRecord record);
            return record;
        }
    }
}
