package expression;

import complex.Complex;
import complex.ComplexExpression;
import factory.Operation;

public class SubstractExpression extends ComplexExpression {
    public SubstractExpression(Complex[] args){
        super(Operation.SUBSTRACTION , args);
    }

    protected Complex executeOneOperation(Complex a , Complex b){
        return a.Scadere(b);
    }
}
