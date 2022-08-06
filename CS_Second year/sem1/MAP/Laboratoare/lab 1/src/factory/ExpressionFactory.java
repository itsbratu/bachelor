package factory;

import complex.Complex;
import complex.ComplexExpression;
import expression.*;

public class ExpressionFactory {

    private static ExpressionFactory exp = null;

    private ExpressionFactory(){}

    public static ExpressionFactory getInstance() {
        if(exp == null){
            exp = new ExpressionFactory();
        }
        return exp;
    }

    public ComplexExpression createExpression(Operation op , Complex[] args){
        if(op == Operation.ADDITION) {
            return new AdditionExpression(args);
        }else if(op == Operation.SUBSTRACTION){
            return new SubstractExpression(args);
        }else if(op == Operation.MULTIPLICATION){
            return new MultiplyExpression(args);
        }else{
            return new DivExpression(args);
        }
    }
}
