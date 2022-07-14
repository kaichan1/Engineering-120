using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafariParkApp
{
    public interface IMovable : ISingleMovable, IMultiMovable
    {
        //properties and methods - public
        //string Move();
        //string Move(int times);

        //public string Move(int times)
        //{
        //    return $"Walking along {times} times";
        //}
        //public string Move()
        //{
        //    return "Walking along";
        //}
    }

    public interface IMultiMovable
    {
        string Move(int times);
    }

    public interface ISingleMovable
    {
        string Move();
    }
}
