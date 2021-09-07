<template>
  <div id="container">
    <div class="user-logo-lang">
      <a href="">
        <img src="../assets/logo.png" alt="" />
      </a>
    </div>
    <a-layout>
      <a-layout-header>
        <a href="">
          <img class="logo" src="../assets/logo.png" alt="" />
          <span class="title">登录页面</span>
        </a>
        <div class="desc">
          的法大师傅士大夫士大夫士大夫士大夫但是撒旦飞洒飞洒地方撒旦范德萨发生
        </div>
      </a-layout-header>
      <a-layout-content>
       <router-view></router-view>
      </a-layout-content>
      <a-layout-footer>
        <div class="link">
          <a href="">帮助</a>
          <a href="">隐私</a>
          <a href="">条款</a>
        </div>
        <div>Copyright © 2018 vueComponent</div>
      </a-layout-footer>
    </a-layout>
  </div>
</template>

<script>
export default {
  name: "UserLayout",
};
</script>

<style lang="less" scoped>
#container {
  .user-logo-lang {
    text-align: right;
    height: 40px;
    position: relative;
    line-height: 44px;
    img {
      width: 20px;
      height: 20px;
    }
  }
  .ant-layout-header {
    text-align: center;
    padding: 30px 0 10px;
    height: 130px;
    a {
      text-decoration: none;
    }
    .logo {
      width: 50px;
      height: 50px;
      margin-right: 16px;
      vertical-align: top;
    }
    .title {
      font-size: 32px;
      font-weight: 400;
      top: 2px;
    }
    .desc {
      font-size: 14px;
      color: white;
      line-height: 20px;
    }
  }
  .ant-layout-footer{
    .link{
      a{
        margin-left: 10px;
      }
    }
    text-align: center;
    width: 500px;
    margin: 0 auto;
  }
}
</style>