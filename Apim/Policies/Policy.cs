namespace Semifinals.Apim.Policies;

public class Policy
{
    public XElement Inbound { get; protected set; }

    public XElement Backend { get; protected set; }

    public XElement Outbound { get; protected set; }

    public XElement OnError { get; protected set; }

    public int Priority { get; }

    public Policy(int priority)
    {
        Inbound = new XElement("inbound");
        Backend = new XElement("backend");
        Outbound = new XElement("outbound");
        OnError = new XElement("on-error");
        Priority = priority;
    }

    public Policy(
        XElement inbound,
        XElement backend,
        XElement outbound,
        XElement onError,
        int priority)
    {
        Inbound = inbound;
        Backend = backend;
        Outbound = outbound;
        OnError = onError;
        Priority = priority;
    }

    public override string ToString()
    {
        var policies = new XElement("policies",
            Inbound,
            Backend,
            Outbound,
            OnError);

        return policies.ToString();
    }
}
