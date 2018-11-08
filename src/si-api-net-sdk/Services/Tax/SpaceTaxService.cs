﻿using System;
using SpaceInvoices.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SpaceInvoices
{
    public class SpaceTaxService: SpaceService
    {
        public SpaceTaxService() : base(null) { }
        public SpaceTaxService(string apiKey) : base(apiKey) { }

        //Sync
        public virtual SpaceTax Create(string organizationId, SpaceTaxCreateOptions tax)
        {
            return Mapper<SpaceTax>.MapFromJson(
                Requestor.Post(tax, $"{Urls.Organizations}/{organizationId}/taxes")
            );
        }

        public virtual SpaceTaxRate AddRateToTax(string taxId, SpaceTaxRate taxRate)
        {
            return Mapper<SpaceTaxRate>.MapFromJson(
                Requestor.Post(taxRate, $"{Urls.Taxes}/{taxId}/taxRates")
            );
        }

        public virtual SpaceTax Edit(string taxId, SpaceTaxEditOptions tax)
        {
            return Mapper<SpaceTax>.MapFromJson(
                Requestor.Put(tax, $"{Urls.Taxes}/{taxId}")
            );
        }

        public virtual Counter Delete(string taxId)
        {
            return Mapper<Counter>.MapFromJson(
                Requestor.Delete($"{Urls.Taxes}/{taxId}")
            );
        }

        public virtual List<SpaceTax> List(string organizationId, string filter = null)
        {
            var filterObj = filter != null ? JsonConvert.DeserializeObject(filter) : null;
            return Mapper<SpaceTax>.MapCollectionFromJson(
                Requestor.Get($"{Urls.Organizations}/{organizationId}/taxes", filterObj)
            );
        }

    }
}
