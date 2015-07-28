using System;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    /// <exception cref="ArgumentOutOfRangeException" accessor="set">ProblemsSolved must be in the range [0, 2]</exception>
    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < 0 || value > 2)
            {
                throw new ArgumentOutOfRangeException("ProblemsSolved" + " must be in the range [0, 2]");
            }

            this.problemsSolved = value;
        }
    }

    /// <exception cref="ArgumentOutOfRangeException">ProblemsSolved must be in the range [0, 2]</exception>
    public override ExamResult Check()
    {
        switch (this.ProblemsSolved)
        {
            case 0:
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 1:
                return new ExamResult(4, 2, 6, "Average result: Half done.");
            case 2:
                return new ExamResult(6, 2, 6, "Excellent result: Everything done.");
            default:
                throw new ArgumentOutOfRangeException("ProblemsSolved" + " must be in the range [0, 2]");
        }
    }
}
