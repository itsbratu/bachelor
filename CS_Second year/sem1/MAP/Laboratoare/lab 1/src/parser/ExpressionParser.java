
package parser;

import complex.Complex;
import complex.ComplexExpression;
import factory.ExpressionFactory;
import factory.Operation;

import java.util.ArrayList;

public class ExpressionParser {

    public Integer valid(String n){
        if( n.matches("^[-+]?[0-9.]+$")){
            return 1;
        }
        else if(n.matches("^[-+]?([0-9.]+[*])?i$")){
            return 2;
        }
        else if(n.matches("^[-+]?[0-9.]+[-+]([0-9.]+[*]?)?i$")){
            return 3;
        }
        return 0;
    }

    public Complex transform(String n){
        if(valid(n) == 1){
            Double real = Double.parseDouble(n);
            Complex ret = new Complex(real, 0);
            return ret;
        }
        if(valid(n) == 2){
            String aux = n.split("[*]?i")[0];
            Double im = Double.parseDouble(aux);
            Complex ret = new Complex(0,im);
            return ret;
        }
        if(valid(n) == 3){

            Integer realSign = 1;
            Integer imSign = 1;
            String[] auxSign = n.split("");
            if(auxSign[0].equals("-")){
                realSign = -1;
            }
            for (int i=1; i< auxSign.length;i++){
                if(auxSign[i].equals("-")){
                    imSign = -1;
                    break;
                }
            }
            Double real = 0.0;
            Double im = 0.0;
            String[] aux = n.split("[-+]");
            if(aux.length == 2){
                real = Double.parseDouble(aux[0])*realSign;
                String imaux = aux[1].split("[*]?i")[0];
                im = Double.parseDouble(imaux)*imSign;
            }
            else{
                real = Double.parseDouble(aux[1])*realSign;
                String imaux = aux[2].split("[*]?i")[0];
                im = Double.parseDouble(imaux)*imSign;
            }
            Complex ret = new Complex(real, im);
            return ret;
        }
        return null;
    }

    public ComplexExpression parse(String[] args){
        ArrayList<String> list_op = new ArrayList<>();
        list_op.add("+");
        list_op.add("*");
        list_op.add("/");
        list_op.add("-");
        String op = args[1];
        Complex[] list_nr = new Complex[args.length/2 +1];
        int j = 0;
        if( args.length %2 == 0){
            return null;
        }
        else{
            for(int i=0; i< args.length; i++){
                if(i%2 == 0){
                    if(valid(args[i]) == 0){
                        return null;
                    }
                    else{
                        Complex nr = transform(args[i]);
                        list_nr[j++] = nr;
                    }
                }
                else{
                    if(!(list_op.contains(args[i])) || !args[i].equals(op)){
                        return null;
                    }
                }
            }
        }
        ExpressionFactory f=ExpressionFactory.getInstance();
        if(op.equals("+")){
            ComplexExpression res = f.createExpression(Operation.ADDITION, list_nr);
            return res;
        }
        if(op.equals("-")){
            ComplexExpression res = f.createExpression(Operation.SUBSTRACTION, list_nr);
            return res;
        }
        if(op.equals("*")){
            ComplexExpression res = f.createExpression(Operation.MULTIPLICATION, list_nr);
            return res;
        }
        if(op.equals("/")){
            ComplexExpression res = f.createExpression(Operation.DIVISION, list_nr);
            return res;
        }
        return null;
    }
}
