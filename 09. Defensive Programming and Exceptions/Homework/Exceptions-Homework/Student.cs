using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private IList<Exam> exams;

    private string firstName;

    private string lastName;

    public Student(string firstName, string lastName, IList<Exam> exams = null)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    /// <exception cref="ArgumentException" accessor="set">Exams cannot be null or empty</exception>
    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        set
        {
            if (value == null || value.Count == 0)
            {
                throw new ArgumentException("Exams cannot be null or empty");
            }

            this.exams = value;
        }
    }

    /// <exception cref="ArgumentException" accessor="set">First name cannot be null or empty.</exception>
    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("FirstName cannot" + " be null or empty");    
            }

            this.firstName = value;
        }
    }

    /// <exception cref="ArgumentException" accessor="set">LastName cannot be null or empty.</exception>
    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("LastName cannot" + " be null or empty");
            }

            this.lastName = value;
        }
    }

    public double CalcAverageExamResultInPercents()
    {
        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] =
                ((double)examResults[i].Grade - examResults[i].MinGrade) /
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }

    public IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }
}
