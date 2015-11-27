using System.Linq;

namespace Iceoz.Mvc.Grid
{
    public interface IGridProcessor<T>
    {
        GridProcessorType ProcessorType { get; set; }

        IQueryable<T> Process(IQueryable<T> items);
    }
}
