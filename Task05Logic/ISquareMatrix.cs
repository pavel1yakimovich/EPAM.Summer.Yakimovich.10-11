namespace Task05Logic
{
    public interface ISquareMatrixVisitor
    {
        void Visit<T>(SquareMatrix<T> matrix);
        void Visit<T>(SymmetricMatrix<T> matrix);
        void Viait<T>(DiagonalMatrix<T> matrix);
    }
}