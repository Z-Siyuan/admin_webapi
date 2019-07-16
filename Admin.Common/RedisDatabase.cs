using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Common
{
    public class RedisDatabase
    {
        private ConnectionMultiplexer _instance;

        public RedisDatabase(string dbname)
        {
            _instance = ConnectionMultiplexer.Connect(ConfigHelper.GetSectionValue(dbname));
        }

        /// <summary>
        /// 根据key获取缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (string.IsNullOrEmpty(_instance.GetDatabase().StringGet(key)))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(_instance.GetDatabase().StringGet(key));
        }

        /// <summary>
        /// 根据key获取缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return _instance.GetDatabase().StringGet(key);
        }

        /// <summary>
        /// 设置缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public bool Set(string key, string value)
        {
            return _instance.GetDatabase().StringSet(key, value);
        }

        /// <summary>
        /// 设置缓存对象
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public bool Set(string key, string value, TimeSpan ts)
        {
            return _instance.GetDatabase().StringSet(key, value, ts);
        }

        /// <summary>
        /// 获取一个锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public bool LockTake(string key, string value, TimeSpan ts)
        {
            return _instance.GetDatabase().LockTake(key, value, ts);
        }

        /// <summary>
        /// 释放一个锁
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool LockRelease(string key, string value)
        {
            return _instance.GetDatabase().LockRelease(key, value);
        }

        /// <summary>
        /// 设置缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value)
        {
            return _instance.GetDatabase().StringSet(key, JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// 设置缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan ts)
        {
            return _instance.GetDatabase().StringSet(key, JsonConvert.SerializeObject(value), ts);
        }


        /// <summary>
        /// 判断在缓存中是否存在该key的缓存数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            return _instance.GetDatabase().KeyExists(key);
        }

        /// <summary>
        /// 往指定的key中添加字符串
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long Apend(string key, string value)
        {
            return _instance.GetDatabase().StringAppend(key, value);
        }

        /// <summary>
        /// 移除指定key的缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            return _instance.GetDatabase().KeyDelete(key);
        }

    }
}
