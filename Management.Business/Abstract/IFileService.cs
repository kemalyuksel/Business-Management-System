using System.Collections.Generic;

namespace Management.Business.Abstract
{
    public interface IFileService
    {

        /// <summary>
        /// Returns the virtual path of the pdf file that it has produced and uploaded.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        string ExportPdf<T>(List<T> list) where T : class, new();

        /// <summary>
        /// Returns excel data as byte array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        byte[] ExportExcel<T>(List<T> list) where T : class, new();
    }
}
