using System;

namespace Delegates_1
{
    public class RequestProcessor<TRequest, TRequestable>
        where TRequest : IRequest
        where TRequestable : IRequestable
{
    private readonly Func<TRequest, bool> _checkFunc;
    private readonly Func<TRequest, TRequestable> _registerFunc;
    private readonly Action<TRequestable> _saveAction;

    public RequestProcessor(Func<TRequest, bool> checkFunc, Func<TRequest, TRequestable> registerFunc, Action<TRequestable> saveAction)
    {
        _checkFunc = checkFunc;
        _registerFunc = registerFunc;
        _saveAction = saveAction;
    }

    public TRequestable Process(TRequest request)
    {
        if (!_checkFunc(request))
            throw new ArgumentException();
        var result = _registerFunc(request);
        _saveAction(result);
        return result;
    }
}
}
