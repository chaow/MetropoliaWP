using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroWPDemo.Models
{

    interface IPersionAction
    {
        void Run();
        void Read_Book();
    }

    /// <summary>
    /// 
    /// </summary>
    public class Person : IPersionAction
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual void Read_Book()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void Run()
        {
            System.Diagnostics.Debug.WriteLine("Person run.");
        }

        /// <summary>
        /// 
        /// </summary>
        private string _name = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set;
            get;
        }

        #region book count

        private int _bookCount = 0;
        public int BookCount
        {
            set
            {
                if (value != _bookCount)
                {
                    _bookCount = value;
                }
            }
            get
            {
                return _bookCount;
            }
        }
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class Student : Person
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Run()
        {
            System.Diagnostics.Debug.WriteLine("Student run.");
            base.Run();
        }

        public override string ToString()
        {
            System.Diagnostics.Debug.WriteLine("Student name: " + Name);
            System.Diagnostics.Debug.WriteLine("Student book count: " + BookCount);
            return base.ToString();
        }

    }

}
