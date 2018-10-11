using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using MyJob.Model;
using MyJob.Service;
using MyJob.ServiceImpl;

namespace MyJob.Factory
{
    public class JobProcessFactory
    {
        private JobProcessFactory() {
            // 不让实例化.
        }


        public static IJobProcessService GetJobProcesser(JobType jobType) {

            string processerClassName = jobType.JobTypeProcesser;

            // 获取当前程序集
            Assembly assembly = Assembly.GetExecutingAssembly();

            // 通过反射，创建对象的实例.
            Object obj = assembly.CreateInstance(processerClassName);

            if (obj is IJobProcessService)
            {
                return (IJobProcessService)obj;
            }

            return null;
        }




    }

}
