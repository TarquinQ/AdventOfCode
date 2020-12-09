using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2020.Models
{
    class Answers
    {
        private int _answerTest1;
        private int _answerTest2;
        private int _answer1;
        private int _answer2;

        public bool AnswerFoundTest1 { get; set; } = false;
        public bool AnswerFoundTest2 { get; set; } = false;
        public bool AnswerFound1 { get; set; } = false;
        public bool AnswerFound2{ get; set; } = false;

        public int AnswerTest1 {
            get => this._answerTest1;
            set
            {
                this._answerTest1 = value;
                this.AnswerFoundTest1 = true;
            }
        }

        public int AnswerTest2 {
            get => this._answerTest2;
            set
            {
                this._answerTest2 = value;
                this.AnswerFoundTest2 = true;
            }
        }

        public int Answer1 {
            get => this._answer1;
            set
            {
                this._answer1 = value;
                this.AnswerFound1 = true;
            }
        }

        public int Answer2 {
            get => this._answer2;
            set
            {
                this._answer2 = value;
                this.AnswerFound2 = true;
            }
        }

        public Answers SetAnswer(int value, bool isTestAnswer, bool isAnswer2)
        {
            if (isTestAnswer)
            {
                if (isAnswer2)
                {
                    this.AnswerTest2 = value;
                }
                else
                {
                    this.AnswerTest1 = value;
                }

            }
            else {
                if (isAnswer2)
                {
                    this.Answer2 = value;
                }
                else
                {
                    this.Answer1 = value;
                }
            }
            return this;
        }
    }
}
