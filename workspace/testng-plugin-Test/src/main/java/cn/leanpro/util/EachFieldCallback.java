/*
 * code https://github.com/jittagornp/excel-object-mapping
 */
package cn.leanpro.util;

import java.lang.reflect.Field;

/**
 * @author redcrow
 */
public interface EachFieldCallback {

    void each(Field field, String name) throws Throwable;
}
