using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data
{
    public static class IJsExtensions
    {
        public static async Task<object> ShowAlert(this IJSRuntime js, string title, string message)
        {
            return await js.InvokeAsync<object>("swal", new
            {
                title = title,
                text = message,
                confirmButtonColor = "#002E6D",
                confirmButtonText = "Ok",
                width = 630,
                padding = 80,
                position = "center"
            });
        }

        public static async Task<object> QuestionAlert(this IJSRuntime js, string title, string message )
        {
            return await js.InvokeAsync<object>("swal", new
            {
                title = title,
                text = message,
                buttons = true,
                showCancelButton = true,
                confirmButtonColor = "#38bd60",
                confirmButtonText = "Yes",
                cancelButtonColor = "#ff5352",
                cancelButtonText = "Cancel",
                width = 630,
                padding = 80
            });
        }
    }
}
