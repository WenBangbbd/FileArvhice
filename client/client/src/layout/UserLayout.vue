<template>
  <div id="components-layout-demo-basic">
    <a-layout>
      <a-layout-header>Header</a-layout-header>
      <a-layout-content>Content</a-layout-content>

      <a-layout-footer>
        <div class="links">
          <a href="_self">帮助</a>
          <a href="_self">隐私</a>
          <a href="_self">条款</a>
        </div>
        <div>Copyright © 2018 vueComponent</div>
      </a-layout-footer>
    </a-layout>
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: "UserLayout",
};
</script>


<style>
a-layout-footer .links {
  margin-bottom: 8px;
  font-size: 14px;
  /* a {
    color: rgba(0, 0, 0, 0.45);
    transition: all 0.3s;
    &:not(:last-child) {
      margin-right: 40px;
    }
  } */

  /* .copyright {
    color: rgba(0, 0, 0, 0.45);
    font-size: 14px;
  } */
}
#components-layout-demo-basic {
  text-align: center;
}
#components-layout-demo-basic .ant-layout-header,
#components-layout-demo-basic .ant-layout-footer {
  background: #7dbcea;
  color: #fff;
}
#components-layout-demo-basic .ant-layout-footer {
  line-height: 1.5;
}
#components-layout-demo-basic .ant-layout-sider {
  background: #3ba0e9;
  color: #fff;
  line-height: 120px;
}
#components-layout-demo-basic .ant-layout-content {
  background: rgba(16, 142, 233, 1);
  color: #fff;
  min-height: 120px;
  line-height: 120px;
}
#components-layout-demo-basic > .ant-layout {
  margin-bottom: 48px;
}
#components-layout-demo-basic > .ant-layout:last-child {
  margin: 0;
}
</style>