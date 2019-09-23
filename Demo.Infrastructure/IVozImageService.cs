using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Business
{
    public interface IVozImageService
    {
        Task<List<string>> LoadAllPages(string url);
    }
}
