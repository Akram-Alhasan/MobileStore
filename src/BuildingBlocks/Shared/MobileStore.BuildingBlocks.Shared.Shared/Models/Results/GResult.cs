using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics.CodeAnalysis;

namespace MobileStore.BuildingBlocks.Shared.Shared.Models.Results
{

    public class GResult<TPayload> : GResult where TPayload : class 
    {
        public TPayload Payload { get; protected set; }
        public new static GResult<TPayload> Success(TPayload result)
        {
            return new GResult<TPayload> { Succeeded = true, Payload = result };
        }
        public new static GResult<TPayload> Failed(params GError[] errors)
        {
            var result = new GResult<TPayload> { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }
    }
    public class GResult 
    {
        public readonly List<GError> _errors = new List<GError>();

        public IEnumerable<GError> Errors => _errors; 
        public  bool Succeeded { get; protected set; }

        public static GResult Success { get; } = new GResult { Succeeded = true };

        public static GResult Failed(params GError[] errors)
        {
            var result = new GResult { Succeeded = false };
            if (errors != null)
            {
                result._errors.AddRange(errors);
            }
            return result;
        }
    }
}
