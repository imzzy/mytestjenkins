/*
 * code https://github.com/jittagornp/excel-object-mapping
 */
package cn.leanpro.converter;

/**
 * @author redcrow
 */
public class StringTypeConverter implements TypeConverter<String> {

    @Override
    public String convert(Object value, String... pattern) {
        if (value instanceof String) {
            return ((String) value).trim();
        }
        
        return null;
    }

}
