﻿using Beeant.Domain.Entities.Security;

namespace Beeant.Domain.Services.Security
{
    public interface ICodeDomainService
    {
        /// <summary>
        /// 验证合法
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool ValidateCode(string tag, string name, CodeType type, string value);

    }
}
