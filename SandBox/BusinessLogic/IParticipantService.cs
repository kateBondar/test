using System;
using System.Collections.Generic;
using Common;
using Common.Models;

namespace BusinessLogic
{
    public interface IParticipantService 
    {
        IEnumerable<LookupItem> GetParticipants();
    }
}