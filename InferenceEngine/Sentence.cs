﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InferenceEngine
{
    public class Sentence
    {
        bool _isFalse;

        public Sentence(bool isFalse)
        {
            _isFalse = isFalse;
        }

        bool isFalse
        {
            get
            {
                return _isFalse;
            }
            set
            {
                _isFalse = value;
            }
        }
    }
}
