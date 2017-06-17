﻿using System;

namespace Beeant.Application.Services.Utility
{
    public interface ICacheApplicationService
    {
        /// <summary>
        /// 得到缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value, DateTime time);

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value, long timeSpan);
        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value);
        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        bool Remove(string key);
      
    }
}
