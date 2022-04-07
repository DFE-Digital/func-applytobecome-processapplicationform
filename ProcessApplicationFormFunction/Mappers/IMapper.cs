using System.Collections.Generic;

namespace ProcessApplicationFormFunction.Mappers;

public interface IMapper<in T1, out T2> where T1: class where T2: class
{
    IEnumerable<T2> Map(IEnumerable<T1> source);
}