using Calculator_CSharp.Models;
using System.Web.Mvc;
using System;

namespace Calculator_CSharp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index(Calculator calculator)
		{
			return View(calculator);
		}

		[HttpPost]
		public ActionResult Calculate(Calculator calculator)
		{
			calculator.Result = CalculateResult(calculator);
			return RedirectToAction("Index", calculator);
		}

		private decimal CalculateResult(Calculator calculator)
		{
			var left = calculator.LeftOperand;
			var right = calculator.RightOperand;
			var sign = calculator.Operator;
			var result = calculator.Result;

			switch (sign)
			{
				case "+":
					result = left + right;
					break;
				case "-":
					result = left - right;
					break;
				case "*":
					result = left * right;
					break;
				case "/":
					result = left / right;
					break;
				case "exp":
					result = (decimal)Math.Pow((double)left, (double)right);
					break;
				case "root":
					result = (decimal)Math.Pow((double)left, (double)(1 / right));
					break;

			}
			return result;
		}
	}
}