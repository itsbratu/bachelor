package expression;

import complex.Complex;
import complex.ComplexExpression;
import factory.Operation;

public class AdditionExpression extends ComplexExpression {
    public AdditionExpression(Complex[] args){
        super(Operation.ADDITION , args);
    }
    @Override
    protected Complex executeOneOperation(Complex a , Complex b){
        return a.Adunare(b);
    }
}
