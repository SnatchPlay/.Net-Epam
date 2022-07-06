using PolynomialObject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PolynomialObject
{
    public sealed class Polynomial
    {
        private List<PolynomialMember> _polynomials = new List<PolynomialMember>();
        public Polynomial()
        {
            _polynomials.Add(new PolynomialMember(0, 0));
        }

        public Polynomial(PolynomialMember member)
        {
            _polynomials.Add(member);
        }

        public Polynomial(IEnumerable<PolynomialMember> members)
        {
            foreach (PolynomialMember member in members)
            {
                _polynomials.Add(member);
            }
        }

        public Polynomial((double degree, double coefficient) member)
        {
            _polynomials.Add(new PolynomialMember(member.degree, member.coefficient));
        }

        public Polynomial(IEnumerable<(double degree, double coefficient)> members)
        {
            foreach (var m in members)
            {
                _polynomials.Add(new PolynomialMember(m.degree, m.coefficient));
            }
        }

        public int Count
        {
            get
            {
                return _polynomials.Count(x => x.Coefficient != 0);
            }
        }

        public double Degree
        {
            get
            {
                return _polynomials.Max(x => x.Degree);
            }
        }

        public void AddMember(PolynomialMember member)
        {
            try
            {
                if (_polynomials.Exists(x => x.Degree == member.Degree) || member.Coefficient == 0)
                    throw new PolynomialArgumentException();
                _polynomials.Add(member);
            }
            catch (NullReferenceException)
            {
                throw new PolynomialArgumentNullException();
            }
        }

        public void AddMember((double degree, double coefficient) member)
        {
            if (_polynomials.Exists(x => x.Degree == member.degree) || member.coefficient == 0)
                throw new PolynomialArgumentException();
            _polynomials.Add(new PolynomialMember(member.degree, member.coefficient));
            
        }

        public bool RemoveMember(double degree)
        {
            int ind = _polynomials.FindIndex(x => x.Degree.Equals(degree));
            if (ind != -1)
            {
                _polynomials.RemoveAt(ind);
                return true;
            }
            return false;
        }

        public bool ContainsMember(double degree)
        {
            PolynomialMember m = _polynomials.Find(x => x.Degree.Equals(degree));
            if (m != null)
            {
                return true;
            }
            return false;
        }

        public PolynomialMember Find(double degree)
        {
            return _polynomials.Find(x => x.Degree.Equals(degree));
        }

        public double this[double degree]
        {
            get
            {
                var temp = _polynomials.Find(x => x.Degree == degree);
                return (temp == null) ? 0 : temp.Coefficient;
            }
            set
            {
                var temp = _polynomials.Find(x => x.Degree == degree);
                if (temp != null)
                {
                    if (temp.Degree != 0)
                    {
                        if (value != 0)
                            _polynomials[_polynomials.IndexOf(temp)].Coefficient = value;
                        else
                            _polynomials.RemoveAt(_polynomials.IndexOf(temp));
                    }
                    else
                        _polynomials.RemoveAt(_polynomials.IndexOf(temp));
                }
                else
                {
                    if (value != 0)
                        _polynomials.Add(new PolynomialMember(degree, value));
                }
            }
        }

        public PolynomialMember[] ToArray()
        {
            return _polynomials.ToArray();
        }

        /// <summary>
        /// Adds two polynomials
        /// </summary>
        /// <param name="a">The first polynomial</param>
        /// <param name="b">The second polynomial</param>
        /// <returns>New polynomial after adding</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if either of provided polynomials is null</exception>
        public static Polynomial operator +(Polynomial a, Polynomial b)
        {
            try
            {
                if (a == null || b == null)
                    throw new PolynomialArgumentNullException();
                Polynomial polynomial = new Polynomial();
                List<double> degress = new List<double>();

                List<PolynomialMember> tmp = new List<PolynomialMember>();
                for (int i = 0; i < b._polynomials.Count; i++)
                {
                    tmp.Add(b._polynomials[i]);
                }
                foreach (PolynomialMember member in b._polynomials)
                {
                    degress.Add(member.Degree);
                }
                for (int i = 0; i < a._polynomials.Count; i++)
                {
                    if (!degress.Contains(a._polynomials[i].Degree))
                    {
                        tmp.Add(a._polynomials[i]);
                        degress.Add(a._polynomials[i].Degree);
                    }
                }

                for (int i = 0; i < a._polynomials.Count; i++)
                {
                    if (b._polynomials.Find(x => x.Degree.Equals(a._polynomials[i].Degree)) != null)
                    {
                        double coef = a._polynomials[i].Coefficient + b._polynomials.Find(x => x.Degree.Equals(a._polynomials[i].Degree)).Coefficient;
                        if (coef != 0)
                        {
                            polynomial.AddMember(new PolynomialMember(a._polynomials[i].Degree, coef));
                            tmp.RemoveAt(tmp.FindIndex(x => x.Degree == a._polynomials[i].Degree));
                        }
                        else
                        {
                            if (polynomial.Count == 0)
                                polynomial.AddMember(new PolynomialMember(0, coef));
                            tmp.RemoveAt(tmp.FindIndex(x => x.Degree == a._polynomials[i].Degree));
                        }
                    }
                }
                for (int i = 0; i < tmp.Count; i++)
                {
                    if (tmp[i].Coefficient == 0)
                        tmp.RemoveAt(i);
                }
                for (int i = 0; i < tmp.Count; i++)
                {
                    polynomial.AddMember(tmp[i]);
                }
                polynomial._polynomials.RemoveAt(0);

                return polynomial;
            }
            catch (Exception)
            {
                throw new PolynomialArgumentNullException();
            }
        }

        /// <summary>
        /// Subtracts two polynomials
        /// </summary>
        /// <param name="a">The first polynomial</param>
        /// <param name="b">The second polynomial</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if either of provided polynomials is null</exception>
        public static Polynomial operator -(Polynomial a, Polynomial b)
        {
            Polynomial polynomial = new Polynomial();

            Polynomial p = new Polynomial();
            p._polynomials.AddRange(a._polynomials);
            p._polynomials.AddRange(b._polynomials);

            List<PolynomialMember> tmp = new List<PolynomialMember>();
            foreach (PolynomialMember item in p._polynomials)
            {
                if (!tmp.Any(x => x.Degree == item.Degree))
                    tmp.Add(item);
            }
            foreach (var i in tmp.OrderBy(x => x.Degree).ToDictionary(x => x.Degree).Keys)
            {
                var ap = a._polynomials.FirstOrDefault(x => x.Degree == i);
                var bp = b._polynomials.FirstOrDefault(x => x.Degree == i);
                if (ap != null && bp != null)
                {
                    var coef = ap.Coefficient - bp.Coefficient;
                    if (coef != 0)
                        polynomial._polynomials.Add(new PolynomialMember(i, coef));
                }
                else if (ap != null && bp == null)
                {
                    var coef = ap.Coefficient;
                    if (coef != 0)
                        polynomial._polynomials.Add(new PolynomialMember(i, coef));
                }
                else if (ap == null && bp != null)
                {
                    var coef = -bp.Coefficient;
                    if (coef != 0)
                        polynomial._polynomials.Add(new PolynomialMember(i, coef));
                }
                else if (ap == null && bp == null) { }
            }
            if (polynomial._polynomials.Count > 1)
                polynomial._polynomials.RemoveAt(0);
            return polynomial;

        }

        /// <summary>
        /// Multiplies two polynomials
        /// </summary>
        /// <param name="a">The first polynomial</param>
        /// <param name="b">The second polynomial</param>
        /// <returns>Returns new polynomial after multiplication</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if either of provided polynomials is null</exception>
        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            Polynomial polynomial = new Polynomial();
            List<double> keys = new List<double>();
            Polynomial t = new Polynomial();
            for (int i = 0; i < a._polynomials.Count; i++)
            {
                for (int j = 0; j < b._polynomials.Count; j++)
                {
                    double key = a._polynomials[i].Degree + b._polynomials[j].Degree;
                    double coef = a._polynomials[i].Coefficient * b._polynomials[j].Coefficient;
                    if (!keys.Contains(key)) keys.Add(key);
                    t.AddMember(
                        new PolynomialMember(key, coef));
                }
            }
            
            foreach (var key in keys)
            {
                double coef = 0;
                for (int j = 0; j < t._polynomials.Count; j++)
                {
                    if (t._polynomials[j].Degree == key)
                        coef += t._polynomials[j].Coefficient;
                }
                polynomial._polynomials.Add(new PolynomialMember(key, coef));
            }
            for (int i = polynomial._polynomials.Count - 1; i >= 0; i--)
            {
                if (polynomial._polynomials[i].Coefficient == 0 && polynomial._polynomials.Count > 1)
                    polynomial._polynomials.RemoveAt(i);
            }
            return polynomial;
        }

        /// <summary>
        /// Adds polynomial to polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial to add</param>
        /// <returns>Returns new polynomial after adding</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Add(Polynomial polynomial)
        {
            if (polynomial == null)
                throw new PolynomialArgumentNullException();
            return this + polynomial;
        }

        /// <summary>
        /// Subtracts polynomial from polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial to subtract</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Subtraction(Polynomial polynomial)
        {
            //if (polynomial == null)
            //    throw new PolynomialArgumentNullException();
            return this - polynomial;
        }

        /// <summary>
        /// Multiplies polynomial with polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial for multiplication </param>
        /// <returns>Returns new polynomial after multiplication</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Multiply(Polynomial polynomial)
        {
            //if (polynomial == null)
            //    throw new PolynomialArgumentNullException();
            return this * polynomial;
        }

        /// <summary>
        /// Adds polynomial and tuple
        /// </summary>
        /// <param name="a">The polynomial</param>
        /// <param name="b">The tuple</param>
        /// <returns>Returns new polynomial after adding</returns>
        public static Polynomial operator +(Polynomial a, (double degree, double coefficient) b)
        {
            //todo
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtract polynomial and tuple
        /// </summary>
        /// <param name="a">The polynomial</param>
        /// <param name="b">The tuple</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        public static Polynomial operator -(Polynomial a, (double degree, double coefficient) b)
        {
            //todo
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies polynomial and tuple
        /// </summary>
        /// <param name="a">The polynomial</param>
        /// <param name="b">The tuple</param>
        /// <returns>Returns new polynomial after multiplication</returns>
        public static Polynomial operator *(Polynomial a, (double degree, double coefficient) b)
        {
            //todo
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds tuple to polynomial
        /// </summary>
        /// <param name="member">The tuple to add</param>
        /// <returns>Returns new polynomial after adding</returns>
        public Polynomial Add((double degree, double coefficient) member)
        {
            //todo
            return this + member;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts tuple from polynomial
        /// </summary>
        /// <param name="member">The tuple to subtract</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        public Polynomial Subtraction((double degree, double coefficient) member)
        {
            //todo
            return this - member;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies tuple with polynomial
        /// </summary>
        /// <param name="member">The tuple for multiplication </param>
        /// <returns>Returns new polynomial after multiplication</returns>
        public Polynomial Multiply((double degree, double coefficient) member)
        {
            //todo
            return this * member;
            throw new NotImplementedException();
        }
    }
}
