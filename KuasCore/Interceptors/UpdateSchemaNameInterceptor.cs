using AopAlliance.Intercept;
using KuasCore.Models;
using System;
using System.Diagnostics;

namespace KuasCore.Interceptors
{
    class UpdateSchemaNameInterceptor : IMethodInterceptor
    {

        public object Invoke(IMethodInvocation invocation)
        {

            Console.WriteLine("UpdateSchemaNameInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);
            Debug.Print("UpdateSchemaNameInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);

            object result = invocation.Proceed();

            if (result is Schema)
            {
                Schema schema = (Schema)result;
                schema.CourseName = schema.CourseName + " 上面偷偷加東西";
                result = schema;
            }

            return result;
        }
    }
}
