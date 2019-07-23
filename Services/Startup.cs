using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class Startup
    {
        public static void ConfigureServices()
        {
            TypeAdapterConfig<Data.Dto.Col, Models.DomainCol>
                .NewConfig()
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Value, s => s.Value);

            TypeAdapterConfig<Data.Dto.Row, Models.DomainRow>
                .NewConfig()
                .Map(d => d.Id, s => s.Id)
                .Map(d => d.UploadDateTime, s => s.WorkSheet.File.UploadDateTime)
                .Map(d => d.Cols, s => s.Cols);
        }
    }
}
