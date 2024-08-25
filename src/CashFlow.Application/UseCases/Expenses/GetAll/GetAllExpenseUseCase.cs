﻿using AutoMapper;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.GetAll
{
    internal class GetAllExpenseUseCase : IGetAllExpenseUseCase
    {
        private readonly IExpensesRepository _repository;
        private readonly IMapper _mapper;

        public GetAllExpenseUseCase(IExpensesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseExpensesJson> Execute()
        {
            var result = await _repository.GetAll();

            return new ResponseExpensesJson
            {
                Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
            };
        }
    }
}
