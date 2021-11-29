using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace HiddenVilla.Server.Extensions
{
    public static class IjsRuntimeExtensions
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jsRuntime, string message) 
            => await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        public static async ValueTask ToastrFailure(this IJSRuntime jsRuntime, string message) 
            => await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        
        public static async ValueTask SwalSuccess(this IJSRuntime jsRuntime, string message) 
            => await jsRuntime.InvokeVoidAsync("ShowSwal", "success", message);
        public static async ValueTask SwalFailure(this IJSRuntime jsRuntime, string message) 
            => await jsRuntime.InvokeVoidAsync("ShowSwal", "error", message);
    }
}