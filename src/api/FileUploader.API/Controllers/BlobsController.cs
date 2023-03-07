﻿using System.Threading;
using System.Threading.Tasks;
using FileUploader.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUploader.API.Controllers
{
    [ApiController]
    [Route("api/blobs")]
    public class BlobsController: ControllerBase
    {
        private readonly IStorageService _storageService;

        public BlobsController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(
            [FromForm(Name = "file")]IFormFile file,
            [FromForm]string email,
            CancellationToken cancellationToken)
        {
            await _storageService.UploadFileAsync(file, email, cancellationToken);
            return NoContent();
        }
    }
}