using System.Collections.Generic;

namespace ProcessApplicationFormFunction.Mappers;

public interface IMapper<T1, out T2> where T1: class where T2: class
{
    IEnumerable<T2> Map(ICollection<T1> source);
}