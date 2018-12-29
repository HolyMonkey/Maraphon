using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGameUnderTests
{
    public class Door
    {
        public bool IsOpened => _dateTimeProvider.Now < _closingTime;

        private double _duration;
        private DateTime _closingTime;
        private IDateTimeProvider _dateTimeProvider;

        public Door(double duration)
        {
            _duration = duration;
            _dateTimeProvider = new NormalDateTimeProvider();
        }

        public Door(double duration,  IDateTimeProvider dateTimeProvider)
        {
            _duration = duration;
            _dateTimeProvider = dateTimeProvider;
        }

        public void Open()
        {
            _closingTime = _dateTimeProvider.Now.AddSeconds(_duration);
        }

        public interface IDateTimeProvider
        {
            DateTime Now { get; }
        }

        public class NormalDateTimeProvider : IDateTimeProvider
        {
            public DateTime Now => DateTime.Now;
        }
    }
}
