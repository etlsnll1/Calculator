
namespace Calculator.InterfaceSpecifications
{
    public interface IArrayService
    {
        T[] Reverse<T>(T[] vals);

        T[] DeletePart<T>(T[] vals, int position);
    }
}
