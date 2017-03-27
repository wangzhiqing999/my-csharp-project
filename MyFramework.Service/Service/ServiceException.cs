using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFramework.Service
{

    /// <summary>
    /// 该异常用于在 服务的方法中，抛出。
    /// 
    /// 主要用在分布式事务时，需要抛出异常，使得整个事务回滚掉。
    /// 
    /// </summary>
    public class ServiceException : Exception
    {

        /// <summary>
        /// 默认构造函数.
        /// </summary>
        public ServiceException()
            : base()
        {

        }


        /// <summary>
        /// 使用指定的错误消息初始化
        /// </summary>
        /// <param name="message"></param>
        public ServiceException(string message)
            : base(message: message)
        {
        }


        /// <summary>
        /// 使用指定错误消息和对作为此异常原因的内部异常的引用来初始化
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public ServiceException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

    }
}
