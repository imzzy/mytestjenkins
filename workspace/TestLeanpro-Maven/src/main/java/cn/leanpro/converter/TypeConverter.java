/*
 * code https://github.com/jittagornp/excel-object-mapping
 */
package cn.leanpro.converter;

/**
 * @author redcrow
 */
public interface TypeConverter<T> {

    T convert(Object value, String... pattern);
}
