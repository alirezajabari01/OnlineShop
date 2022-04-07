using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using OnlineShop.Controllers;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShop.ConfigurationServices
{
    public class FileUploadOperation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
			if (operation.Parameters == null)
			{
				return;
			}
			foreach (var parameter in operation.Parameters)
			{
				var description = context.ApiDescription.ParameterDescriptions
					.First(p => p.Name == parameter.Name);
				var routeInfo = description.RouteInfo;
				


				if (string.IsNullOrEmpty(parameter.Name))
				{
					parameter.Name = description.ModelMetadata?.Name;
				}

				if (parameter.Description == null)
				{
					parameter.Description = description.ModelMetadata?.Description;
				}

				if (routeInfo == null)
				{
					continue;
				}

				parameter.Required |= !routeInfo.IsOptional;
			}

		}
	}
}
