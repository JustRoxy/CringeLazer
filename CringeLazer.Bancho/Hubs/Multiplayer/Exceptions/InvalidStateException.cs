using System.Runtime.Serialization;
using Microsoft.AspNetCore.SignalR;

namespace CringeLazer.Bancho.Hubs.Multiplayer.Exceptions;

[Serializable]
public class InvalidStateException : HubException
{
    public InvalidStateException(string message)
        : base(message)
    {
    }

    protected InvalidStateException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}
