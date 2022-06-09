﻿using GwOnlineLibrary.Domain;

namespace GwOnlineLibrary.Interfaces;

internal interface IApi
{
    Task<TokenGw> LogonAsync();
    Task<string> GetKeyAsync();
    Task<TransactionResult> TransactionAsync(TransactionRequest request);
}