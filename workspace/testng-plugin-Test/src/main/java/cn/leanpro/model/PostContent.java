package cn.leanpro.model;

import cn.leanpro.annotation.Column;

public class PostContent {

	@Column(name="title")
	private String title;
	@Column(name="descContent")
	private String descContent;
	@Column(name="newtitle")
	private String newtitle;
	@Column(name="newdescContent")
	private String newdescContent;
	@Column(name="deltitle")
	private String deleteTitle;
	
	public String getDeleteTitle() {
		return deleteTitle;
	}
	public void setDeleteTitle(String deleteTitle) {
		this.deleteTitle = deleteTitle;
	}
	public String getNewtitle() {
		return newtitle;
	}
	public void setNewtitle(String newtitle) {
		this.newtitle = newtitle;
	}
	public String getNewdescContent() {
		return newdescContent;
	}
	public void setNewdescContent(String newdescContent) {
		this.newdescContent = newdescContent;
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public String getDescContent() {
		return descContent;
	}
	public void setDescContent(String descContent) {
		this.descContent = descContent;
	}
	
	
}
