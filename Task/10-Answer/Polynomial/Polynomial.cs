using System;
using System.Linq;
using System.Collections.Generic;
using PolynomialObject.Exceptions;

namespace PolynomialObject
{
    public sealed class Polynomial
    {
        private List<PolynomialMember> _polynomials=new List<PolynomialMember>();
        public Polynomial()
        {
            _polynomials.Add(new PolynomialMember(0, 0));
            //todo
            ///throw new NotImplementedException();
        }

        public Polynomial(PolynomialMember member)
        {
            _polynomials.Add(member);
            //todo
            ///throw new NotImplementedException();
        }

        public Polynomial(IEnumerable<PolynomialMember> members)
        {
            foreach (PolynomialMember member in members)
            {
                _polynomials.Add(member);
            }
            //todo
           /// throw new NotImplementedException();
        }

        public Polynomial((double degree, double coefficient) member)
        {
            _polynomials.Add(new PolynomialMember(member.degree, member.coefficient));
            //todo
            ///throw new NotImplementedException();
        }

        public Polynomial(IEnumerable<(double degree, double coefficient)> members)
        {
            foreach (var m in members)
            {

                _polynomials.Add(new PolynomialMember(m.degree,m.coefficient));
            }
            
            //todo
            ///throw new NotImplementedException();
        }

        /// <summary>
        /// The amount of not null polynomial members in polynomial 
        /// </summary>
        public int Count
        {
            get
            {
                return _polynomials.Count(x => x.Coefficient != 0);
                //todo
                ///throw new NotImplementedException();
            }
        }

        /// <summary>
        /// The biggest degree of polynomial member in polynomial
        /// </summary>
        public double Degree
        {
            get
            {
                return _polynomials.Max(x => x.Degree);
                //todo
                ///throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Adds new unique member to polynomial 
        /// </summary>
        /// <param name="member">The member to be added</param>
        /// <exception cref="PolynomialArgumentException">Throws when member to add with such degree already exist in polynomial</exception>
        /// <exception cref="PolynomialArgumentNullException">Throws when trying to member to add is null</exception>
        public void AddMember(PolynomialMember member)
        {
            _polynomials.Add(member);
            //todo
            ///throw new NotImplementedException();
        }

        /// <summary>
        /// Adds new unique member to polynomial from tuple
        /// </summary>
        /// <param name="member">The member to be added</param>
        /// <exception cref="PolynomialArgumentException">Throws when member to add with such degree already exist in polynomial</exception>
        public void AddMember((double degree, double coefficient) member)
        {
            _polynomials.Add(new PolynomialMember(member.degree,member.coefficient));
            //todo
            ///throw new NotImplementedException();
        }

        /// <summary>
        /// Removes member of specified degree
        /// </summary>
        /// <param name="degree">The degree of member to be deleted</param>
        /// <returns>True if member has been deleted</returns>
        public bool RemoveMember(double degree)
        {
            ///double max=_polynomials.Max(x=>x.Degree);
            int ind=_polynomials.FindIndex(x => x.Degree.Equals(degree));
            
            if (ind != -1)
            {
                _polynomials.RemoveAt(ind);
                return true;
            }
            return false;
            //todo
            ///throw  new NotImplementedException();
        }

        /// <summary>
        /// Searches the polynomial for a method of specified degree
        /// </summary>
        /// <param name="degree">Degree of member</param>
        /// <returns>True if polynomial contains member</returns>
        public bool ContainsMember(double degree)
        {
            PolynomialMember m= _polynomials.Find(x => x.Degree.Equals(degree));
            if (m != null)
            {
                return true;
            }
            //todo
            ///throw new NotImplementedException();
            return false;
        }

        /// <summary>
        /// Finds member of specified degree
        /// </summary>
        /// <param name="degree">Degree of member</param>
        /// <returns>Returns the found member or null</returns>
        public PolynomialMember Find(double degree)
        {
            return _polynomials.Find(x => x.Degree.Equals(degree));
            //todo
            ///throw new NotImplementedException();
        }

        /// <summary>
        /// Gets and sets the coefficient of member with provided degree
        /// If there is no null member for searched degree - return 0 for get and add new member for set
        /// </summary>
        /// <param name="degree">The degree of searched member</param>
        /// <returns>Coefficient of found member</returns>
        public double this[double degree]
        {
            get
            {
                return degree;
                //todo
                ///throw new NotImplementedException();
            }
            set 
            { 
                degree = value;
                //todo
                ///throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Convert polynomial to array of included polynomial members 
        /// </summary>
        /// <returns>Array with not null polynomial members</returns>
        public PolynomialMember[] ToArray()
        {
            return _polynomials.ToArray();
            //todo
            ///throw new NotImplementedException();
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
            Polynomial polynomial = new Polynomial();
            List<double> degress = new List<double>();
            Polynomial tmp=new Polynomial();
            for(int i=0;i< b._polynomials.Count;i++)
            {
                tmp._polynomials[i] = b._polynomials[i];
            }
            foreach(PolynomialMember member in b._polynomials)
            {
                degress.Add(member.Degree);
            }
            ///PolynomialMember member = new PolynomialMember(0, 0);
            for(int i = 0; i < a._polynomials.Count; i++)
            {
                if (!degress.Contains(a._polynomials[i].Degree))
                {
                    tmp.AddMember(a._polynomials[i]);
                }
            }
            ///Polynomial tmp = a._polynomials.Concat(b._polynomials);
            ///var unq=tmp.ToArray().GroupBy(x=>x.Degree).Select(x=>x.First());
            for(int i = 0; i < a._polynomials.Count; i++)
            {
                if (b._polynomials.Find(x => x.Degree.Equals(a._polynomials[i].Degree)) != null)
                {
                    double coef = a._polynomials[i].Coefficient + b._polynomials.Find(x => x.Degree.Equals(a._polynomials[i].Degree)).Coefficient;
                    double degre = 0;
                    if (coef != 0)
                    {
                        polynomial.AddMember(new PolynomialMember(a._polynomials[i].Degree, coef));
                    }
                    else
                    {
                        polynomial.AddMember(new PolynomialMember(degre, coef));
                    }
                }

            }
           /// _ = polynomial._polynomials.Concat(unq);
           for(int i = 0; i < tmp.Count; i++)
            {
                polynomial.AddMember(tmp._polynomials[i]);
            }
            polynomial._polynomials.RemoveAt(0);



            ////_ = a._polynomials.OrderBy(x => x.Degree);
            ////_ = b._polynomials.OrderBy(x => x.Degree);
            ////a._polynomials.AddRange(b._polynomials);

            ////int c = a._polynomials.Count;
            ////if(b._polynomials.Count >c)c = b._polynomials.Count;
            //int k = 0;
            //for (int i = 0; i < a._polynomials.Count; i++)
            //{
            //    if (b._polynomials.Find(x => x.Degree.Equals(a._polynomials[i].Degree)) != null)
            //    {
            //        double coef = a._polynomials[i].Coefficient + b._polynomials.Find(x => x.Degree.Equals(a._polynomials[i].Degree)).Coefficient;
            //        double degre = 0;
            //        if (coef != 0)
            //        {
            //            polynomial.AddMember(new PolynomialMember(a._polynomials[i].Degree, coef));
            //        }
            //        else
            //        {
            //            polynomial.AddMember(new PolynomialMember(degre, coef));
            //        }
            //    }
            //    else
            //    {
            //        polynomial.AddMember(a._polynomials[i]);
            //        polynomial.AddMember(b._polynomials[i]);
            //    }
            //    k = i;
            //}
            //if (b._polynomials.Count != a._polynomials.Count)
            //{
            //    while (k != b._polynomials.Count)
            //    {
            //        polynomial.AddMember(b._polynomials[k]);
            //        k++;
            //    }
            //}
            ////polynomial._polynomials.InsertRange(k, b._polynomials);
            //polynomial._polynomials.RemoveAt(0);
            return polynomial;
            //todo
            ///throw new NotImplementedException();
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
            //todo
            throw new NotImplementedException();
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
            //todo
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds polynomial to polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial to add</param>
        /// <returns>Returns new polynomial after adding</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Add(Polynomial polynomial)
        {
            //todo
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subtracts polynomial from polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial to subtract</param>
        /// <returns>Returns new polynomial after subtraction</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Subtraction(Polynomial polynomial)
        {
            //todo
            throw new NotImplementedException();
        }

        /// <summary>
        /// Multiplies polynomial with polynomial
        /// </summary>
        /// <param name="polynomial">The polynomial for multiplication </param>
        /// <returns>Returns new polynomial after multiplication</returns>
        /// <exception cref="PolynomialArgumentNullException">Throws if provided polynomial is null</exception>
        public Polynomial Multiply(Polynomial polynomial)
        {
            //todo
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
