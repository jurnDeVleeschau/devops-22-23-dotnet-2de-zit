﻿using Domain.VirtualMachines.Contract;
using Shared.VMContracts;


namespace Services.VMContracts
{
    public class FakeVMContractService : IVMContractService
    {
        private List<VMContract> _contracts;

        public FakeVMContractService()
        {
            _contracts = VMContractFaker.Instance.Generate(100);

        }

        public Task<VMContractResponse.Create> CreateAsync(VMContractRequest.Create request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(VMContractRequest.Delete request)
        {
            throw new NotImplementedException();
        }

        public Task<VMContractResponse.Edit> EditAsync(VMContractRequest.Edit request)
        {
            throw new NotImplementedException();
        }

        public Task<VMContractResponse.Detail> GetDetailAsync(VMContractRequest.GetDetail request)
        {
            throw new NotImplementedException();
        }

        public Task<VMContractResponse.GetDetail> GetDetailThroughVMIdAsync(VMContractRequest.GetDetailThroughVMId request)
        {
            throw new NotImplementedException();
        }

        public Task<VMContractResponse.Index> GetFromDate(VMContractRequest.GetByDate request)
        {
            throw new NotImplementedException();
        }

        public Task<VMContractResponse.GetIndex> GetIndexAsync(VMContractRequest.GetIndex request)
        {
            throw new NotImplementedException();
        }

        Task<VMContractResponse.GetDetail> IVMContractService.GetDetailAsync(VMContractRequest.GetDetail request)
        {
            throw new NotImplementedException();
        }
    }
}
