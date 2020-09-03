using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PushNotifications.Client.Net
{
    public class ResponseResult
    {
        public static readonly ResponseResult Success = new ResponseResult();

        public ResponseResult()
        {
            Errors = new List<string>();
        }

        public ResponseResult(params string[] errors)
        {
            this.Errors = errors;
        }

        public IEnumerable<string> Errors { get; set; }

        public bool IsSuccess { get { return HasNoErrors(); } }

        private bool HasNoErrors()
        {
            return Errors == null || !Errors.Any();
        }
    }
    public class BulkResponseResult<T> where T : ResponseResult
    {
        public BulkResponseResult()
        {
            BulkResult = new List<T>();
        }

        public List<T> BulkResult { get; set; }
        public IEnumerable<string> Errors { get { return BulkResult.Where(x => x.Errors != null && x.Errors.Any()).SelectMany(x => x.Errors); } }
        public bool IsSuccess
        {
            get { return BulkResult.Where(x => x.Errors != null && x.Errors.Any()).Any() == false; }
        }

    }

    public class ResponseResult<T> : ResponseResult
    {
        public ResponseResult()
        {

        }

        public ResponseResult(T result)
        {
            Result = result;
        }

        public ResponseResult(T result, params string[] errors)
            : base(errors)
        {
            Result = result;
        }
        public ResponseResult(params string[] errors) : base(errors) { }

        public T Result { get; set; }
    }

    static class ResponseResultExtensions
    {
        public static ErrorModel ToError(this ResponseResult result)
        {
            if (result == null) throw new ArgumentNullException("result");

            return new ErrorModel
            {
                Errors = result.Errors.ToArray()
            };
        }
    }

    public class CreationResult : ErrorModel
    {
        public Guid Id { get; set; }
        public string Tenant { get; set; }
    }

    public class ErrorModel
    {
        public string[] Errors { get; set; }
    }

    public class CreationResult<T>
    {
        public T Id { get; set; }
    }
}
