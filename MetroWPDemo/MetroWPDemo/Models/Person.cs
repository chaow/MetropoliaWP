using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroWPDemo.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Person : ModelBase
    {
        private string _name = "";
        public string Name
        {
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("personName");
                }
            }
            get
            {
                return _name;
            }
        }

        private string _nickName = "";
        public string Nickname
        {
            set
            {
                if (value != _nickName)
                {
                    _nickName = value;
                    NotifyPropertyChanged("nickName");
                }
            }
            get
            {
                return _nickName;
            }
        }

        private int _age = 0;
        public int Age
        {
            set
            {
                if (value != _age)
                {
                    _age = value;
                    NotifyPropertyChanged("personAge");
                }
            }
            get
            {
                return _age;
            }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public class Student : Person
    {

        public override string ToString()
        {
            System.Diagnostics.Debug.WriteLine("Student name: " + Name);
            return base.ToString();
        }

    }

}
