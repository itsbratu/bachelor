import parser.ExpressionParser;
import complex.Complex;
import complex.ComplexExpression;

public class Main {

    public static void main(String[] args) {
        ExpressionParser pars = new ExpressionParser();
        ComplexExpression rez = pars.parse(args);
        Complex exprResult = rez.execute();
        exprResult.Args();
    }
}
