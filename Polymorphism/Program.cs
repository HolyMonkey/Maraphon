using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidableValue email = new ValidableValue("roman@sakutin.ru", new ContainCharRule());
            ValidableValue name = new ValidableValue("Romaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaan", new LengthRule(10)); //ошибка
            ValidableValue name2 = new ValidableValue("Roman", new LengthRule(10)); //Всё норм

            //

            ValidableValue shortedEmail = new ValidableValue("romaaaaaaaaaan@sakutin.ru", Rule.GetEmailRule()); //ошибка
            ValidableValue shortedEmail2 = new ValidableValue("roman@sakutin.ru",
                                                                new Rules()
                                                                .MaxLength(100)
                                                                .ContainChar('@')
                                                                .ContainString(".ru")); //Всё норм
        }
    }

    class ValidableValue
    {
        private object _value;
        private Rule _rule;

        public ValidableValue(object value, Rule rule)
        {
            if (rule.Validate(value) == false)
                throw new ArgumentException(rule.ErrorMessage);

            _value = value;
        }

        public object Value => _value;
    }

    public abstract class Rule
    {
        public abstract string ErrorMessage { get; }

        public abstract bool Validate(object value);

        public static Rule GetEmailRule()
        {
            return new CompositeRules(new ContainCharRule(), new LengthRule(10));
        }
    }

    public class Rules
    {
        private List<Rule> _rules;

        public Rules MaxLength(int maxLength)
        {
            _rules.Add(new LengthRule(maxLength));

            return this;
        }

        public Rules ContainChar(char symbol)
        {
            _rules.Add(new ContainCharRule());

            return this;
        }

        public Rules ContainString(string substring)
        {
            //_rules.Add(new ContainCharRule());

            return this;
        }

        public Rules Email()
        {
            _rules.Add(new EmailRule());

            return this;
        }

        public static implicit operator Rule(Rules builder)
        {
            return new CompositeRules(builder._rules.ToArray());
        }
    }

    class EmailRule : Rule
    {
        private Rule _composite;

        public override string ErrorMessage => _composite.ErrorMessage;

        public override bool Validate(object value)
        {
            return _composite.Validate(value);
        }

        public EmailRule()
        {
            _composite = new CompositeRules(new ContainCharRule(), new LengthRule(10));
        }
    }

    class ContainCharRule : Rule
    {
        public override string ErrorMessage => "Value must be contain @";

        public override bool Validate(object value)
        {
            if (value is string)
            {
                var email = (string)value;

                return email.Contains("@");
            }

            return false;
        }
    }

    class LengthRule : Rule
    {
        public override string ErrorMessage => $"Value must be shorter than {_maxLength}";

        private int _maxLength;

        public LengthRule(int maxLength)
        {
            _maxLength = maxLength;
        }

        public override bool Validate(object value)
        {
            if (value is string)
            {
                var strValue = (string)value;

                return strValue.Length < _maxLength;
            }

            return false;
        }
    }

    class CompositeRules : Rule
    {
        private Rule[] rules;

        public CompositeRules(params Rule[] rules)
        {
            this.rules = rules;
        }

        public override string ErrorMessage => rules.Select(x => x.ErrorMessage).Aggregate((a, b) => $"{a} , {b}");
        public override bool Validate(object value)
        {
            return rules.All(rule => rule.Validate(value));
        }
    }
}