using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace Four.WebApi.UnityFactory.AOPUnit
{
    public class LogBehavior : IInterceptionBehavior
    {
        public bool WillExecute { get { return true; } }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Write Log");

            return getNext().Invoke(input,getNext);
        }
    }
}