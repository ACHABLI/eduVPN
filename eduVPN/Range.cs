﻿/*
    eduVPN - End-user friendly VPN

    Copyright: 2017, The Commons Conservancy eduVPN Programme
    SPDX-License-Identifier: GPL-3.0+
*/

using Prism.Mvvm;

namespace eduVPN
{
    /// <summary>
    /// Range descriptor
    /// </summary>
    public class Range<T> : BindableBase
    {
        #region Properties

        /// <summary>
        /// Range minimum value
        /// </summary>
        public T Minimum
        {
            get { return _minimum; }
            set { SetProperty(ref _minimum, value); }
        }
        private T _minimum;

        /// <summary>
        /// Range maximum value
        /// </summary>
        public T Maximum
        {
            get { return _maximum; }
            set { SetProperty(ref _maximum, value); }
        }
        private T _maximum;

        /// <summary>
        /// Range current value
        /// </summary>
        public T Value
        {
            get { return _value; }
            set { SetProperty(ref _value, value); }
        }
        private T _value;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructs a range descriptor
        /// </summary>
        public Range()
        {
        }

        /// <summary>
        /// Constructs a range descriptor
        /// </summary>
        public Range(T min, T max)
        {
            _minimum = min;
            _maximum = max;
        }

        /// <summary>
        /// Constructs a range descriptor
        /// </summary>
        public Range(T min, T max, T val) :
            this(min, max)
        {
            _value = val;
        }

        #endregion
    }
}
