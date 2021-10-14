using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAddressBook.Services.Interfaces
{
    public interface IImageService //This interface will get used for the rest of the cohort.
    {
        Task<byte[]> EndcodeImageAsync(IFormFile file);

        Task<byte[]> EncodeImageAsync(string fileName);

        string DecodeImage(byte[] data, string type);

        string ContentType(IFormFile file);

        int Size(IFormFile file);
    }
}
