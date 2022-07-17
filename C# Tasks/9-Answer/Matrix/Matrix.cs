using System;
using System.Runtime.Serialization;

namespace MatrixLibrary
{

    public class MatrixException : Exception, ISerializable
    {

        public MatrixException() : base() { }

    }


    public class Matrix : ICloneable
    {
        /// <summary>
        /// Number of rows.
        /// </summary>
        readonly int rows;
        readonly int cols;
        readonly double[,] matrix;
        public int Rows
        {
            get => rows;
        }

        /// <summary>
        /// Number of columns.
        /// </summary>
        public int Columns
        {
            get => cols;
        }

        /// <summary>
        /// Gets an array of floating-point values that represents the elements of this Matrix.
        /// </summary>
        public double[,] Array
        {
            get => matrix;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Matrix(int rows, int columns)
        {
            try
            {
                int rows_ = rows;
                int columns_ = columns;
                double[,] array = new double[rows_, columns_];
                for (int i = 0; i < rows_; i++)
                {
                    for (var j = 0; j < columns_; j++)
                    {
                        array[i, j] = 0;
                    }
                }


                this.rows = rows;
                this.cols = columns;
                this.matrix = array;
            }
            catch (Exception)
            {
                throw new ArgumentOutOfRangeException("rows");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class with the specified elements.
        /// </summary>
        /// <param name="array">An array of floating-point values that represents the elements of this Matrix.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Matrix(double[,] array)
        {
            try
            {
                this.rows = array.GetLength(0);
                this.cols = array.GetLength(1);
                this.matrix = array;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentNullException("array");
            }
            catch (Exception)
            {
                throw new MatrixException();
            }






        }

        /// <summary>
        /// Allows instances of a Matrix to be indexed just like arrays.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="ArgumentException"></exception>
        public double this[int row, int column]
        {

            get
            {
                try
                {
                    return matrix[row, column];
                }
                catch (Exception)
                {
                    throw new ArgumentException("row");
                }
            }
            set
            {
                try { this.matrix[row, column] = value; }
                catch (Exception)
                {
                    throw new ArgumentException("row");
                }
            }
        }



        /// <summary>
        /// Creates a deep copy of this Matrix.
        /// </summary>
        /// <returns>A deep copy of the current object.</returns>
        public object Clone()
        {

            Matrix array = new Matrix(this.Rows, this.Columns);
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (var j = 0; j < this.matrix.GetLength(1); j++)
                {
                    double tmp = this.matrix[i, j];
                    array[i, j] = tmp;
                }
            }
            return array;
        }

        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is sum of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            try
            {
                Matrix resmatrix = new Matrix(matrix1.rows, matrix1.cols);
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (var j = 0; j < matrix1.cols; j++)
                    {
                        resmatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                return resmatrix;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentNullException("matrix1");
            }
            catch (Exception)
            {
                throw new MatrixException();
            }
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is subtraction of two matrices</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            try
            {
                Matrix resmatrix = new Matrix(matrix1.rows, matrix1.cols);
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (var j = 0; j < matrix1.cols; j++)
                    {
                        resmatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
                return resmatrix;
            }

            catch (NullReferenceException)
            {
                throw new ArgumentNullException("matrix1");
            }
            catch (ArgumentException)
            {
                throw new MatrixException();
            }
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is multiplication of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            try
            {
                if (matrix1.rows != matrix2.cols && matrix2.rows != matrix1.cols)
                {
                    throw new MatrixException();
                }
                Matrix resmatrix = new Matrix(matrix1.rows, matrix2.cols);
                for (int i = 0; i < resmatrix.rows; i++)
                {
                    for (var j = 0; j < resmatrix.cols; j++)
                    {
                        for (int k = 0; k < matrix1.cols; k++)
                        {
                            resmatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                        }
                    }
                }
                return resmatrix;
            }

            catch (NullReferenceException)
            {
                throw new ArgumentNullException("matrix1");
            }
            catch (Exception)
            {
                throw new MatrixException();
            }



        }

        /// <summary>
        /// Adds <see cref="Matrix"/> to the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for adding.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Add(Matrix matrix)
        {
            try
            {
                if (matrix.rows != this.rows || matrix.cols != this.cols)
                {
                    throw new MatrixException();
                }
                Matrix matrix1 = new Matrix(matrix.rows, matrix.cols);
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (var j = 0; j < matrix1.cols; j++)
                    {
                        matrix1[i, j] = this.matrix[i, j] + matrix[i, j];
                    }
                }
                return matrix1;
            }

            catch (NullReferenceException)
            {
                throw new ArgumentNullException("matrix");
            }


        }

        /// <summary>
        /// Subtracts <see cref="Matrix"/> from the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for subtracting.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Subtract(Matrix matrix)
        {
            try
            {
                if (matrix.rows != this.rows || matrix.cols != this.cols)
                {
                    throw new MatrixException();
                }
                Matrix matrix1 = new Matrix(matrix.rows, matrix.cols);
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (var j = 0; j < matrix1.cols; j++)
                    {
                        matrix1[i, j] = this.matrix[i, j] - matrix[i, j];
                    }
                }
                return matrix1;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentNullException("matrix");
            }

        }

        /// <summary>
        /// Multiplies <see cref="Matrix"/> on the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for multiplying.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Multiply(Matrix matrix)
        {
            try
            {
                if (matrix.rows != this.cols)
                {
                    throw new MatrixException();
                }
                Matrix matrix1 = new Matrix(this.rows, matrix.cols);
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (var j = 0; j < matrix1.cols; j++)
                    {

                        for (int k = 0; k < this.cols; k++)
                        {
                            matrix1[i, j] += this.matrix[i, k] * matrix[k, j];
                        }
                    }
                }
                return matrix1;
            }
            catch (NullReferenceException)
            {
                throw new ArgumentNullException("matrix");
            }

        }

        /// <summary>
        /// Tests if <see cref="Matrix"/> is identical to this Matrix.
        /// </summary>
        /// <param name="obj">Object to compare with. (Can be null)</param>
        /// <returns>True if matrices are equal, false if are not equal.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Matrix)) { return false; }
            if (obj == null) { return false; }
            Matrix bj = obj as Matrix;
            int c = this.cols;
            int r = this.rows;
            if (bj.cols < this.cols)
            {
                c = bj.cols;
            }
            if (bj.rows < this.rows)
            {
                r = bj.rows;
            }
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (this.matrix[i, j] != bj.matrix[i, j])
                    {
                        return false;
                    }
                }

            }
            return true;

        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
